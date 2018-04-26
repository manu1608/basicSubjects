using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.IO;
using Plugin.Connectivity;
using System.Diagnostics;

using EZCode.Model;

namespace EZCode.Services
{
    public class AzureService
    {
        public MobileServiceClient Client { get; set; } = null;
        IMobileServiceSyncTable<BaiTap> baiTapTable;
        IMobileServiceSyncTable<CongThuc> congThucTable;
        IMobileServiceSyncTable<DeThi> deThiTable;
        IMobileServiceSyncTable<MonHoc> monHocTable;

        public async Task Initialize()
        {
            Debug.WriteLine("[ThanhHM] Function: AzureService::Initialize");
            // Check if Client is initialize or not
            if (Client.SyncContext.IsInitialized == false)
                return;

            var appUrl = "https://ezcode.azurewebsites.net";

            // Create client
            Client = new MobileServiceClient(appUrl);

            // InitialzeDatabase for path
            var dbPath = "ezcode.db";
            dbPath = Path.Combine(MobileServiceClient.DefaultDatabasePath, dbPath);

            // Setup local sqlite store and initialize table
            var store = new MobileServiceSQLiteStore(dbPath);

            // Define table
            store.DefineTable<MonHoc>();

            // Initialize SyncContext
            await Client.SyncContext.InitializeAsync(store);

            // Get sync table that will call out to azure
            monHocTable = Client.GetSyncTable<MonHoc>();
        }

        public async Task SyncData()
        {
            Debug.WriteLine("[ThanhHM] Function: AzureService::SyncData");
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;

                await monHocTable.PullAsync("allMonHoc", monHocTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unable to sync data, that is alright as we have offline capabilities: " + e);
            }
        }

        //public async Task<List<MonHoc>> GetMonHoc()
        public async Task<IEnumerable<MonHoc>> GetMonHoc()
        {
            Debug.WriteLine("[ThanhHM] Function: AzureService::GetMonHoc");
            // Initialize & Sync
            await Initialize();
            await SyncData();
            
            //return await monHocTable.OrderBy(c => c.Id).ToListAsync();
            return await monHocTable.OrderBy(c => c.Id).ToEnumerableAsync();
        }
    }
}
