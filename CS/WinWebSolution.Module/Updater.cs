using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace WinWebSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace os, Version currentDBVersion) : base(os, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Order order = ObjectSpace.CreateObject <Order>();
            order.Name = "Order 1";
            for (int i = 0; i < 5; i++) {
                OrderItem item = ObjectSpace.CreateObject<OrderItem>();
                item.Subject = "OrderItem " + i.ToString();
                item.Order = order;
                item.UpdateModifiedOn(DateTime.Now + TimeSpan.FromDays(i));
                item.Save();
            }
        }
    }
}
