using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Xpo.Metadata;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WinWebSolution.Module {
    public abstract class SortListViewControllerBase : ViewController<ListView> {
        public SortListViewControllerBase() {
            TargetObjectType = typeof(OrderItem);
            TargetViewNesting = Nesting.Nested;
        }
    }
    [DefaultClassOptions]
    public class Order : BaseObject {
        public Order(Session session) : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        [Association("Order-Items"), Aggregated]
        public XPCollection<OrderItem> Items {
            get {
                XPCollection<OrderItem> xpCollection = GetCollection<OrderItem>("Items");
                SortingHelper.Sort(xpCollection, "ModifiedOn", SortingDirection.Descending);
                return xpCollection;
            }
        }
    }
    public class OrderItem : BaseObject {
        public OrderItem(Session session) : base(session) { }
        [Persistent("ModifiedOn"), ValueConverter(typeof(UtcDateTimeConverter))]
        protected DateTime _ModifiedOn = DateTime.Now;
        [PersistentAlias("_ModifiedOn")]
        [Browsable(false)]
        public DateTime ModifiedOn {
            get { return _ModifiedOn; }
        }
        internal virtual void UpdateModifiedOn() {
            UpdateModifiedOn(DateTime.Now);
        }
        internal virtual void UpdateModifiedOn(DateTime date) {
            _ModifiedOn = date;
            Save();
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue) {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "Subject" || propertyName == "Description") {
                UpdateModifiedOn();
            }
        }
        private string _Subject;
        public string Subject {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
        private string _Description;
        public string Description {
            get { return _Description; }
            set { SetPropertyValue("Description", ref _Description, value); }
        }
        private Order _Order;
        [Association("Order-Items")]
        public Order Order {
            get { return _Order; }
            set { SetPropertyValue("Order", ref _Order, value); }
        }
    }
    public class SortingHelper {
        public static void Sort(XPBaseCollection collection, string property, SortingDirection direction) {
            bool isSortingAdded = false;
            foreach (SortProperty sortProperty in collection.Sorting) {
                if (sortProperty.Property.Equals(DevExpress.Data.Filtering.CriteriaOperator.Parse(property))) {
                    isSortingAdded = true;
                }
            }
            if (!isSortingAdded) {
                collection.Sorting.Add(new SortProperty(property, direction));
            }
        }
    }
}