namespace Ex03.GarageLogic
{
    public class GarageCustomer
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private GarageManager.eCarStatus m_CarStatus;

        public GarageCustomer(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            this.r_Vehicle = i_Vehicle;
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerPhone = i_OwnerPhone;
            m_CarStatus = GarageManager.eCarStatus.InFix;
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhone
        {
            get { return r_OwnerPhone; }
        }

        public GarageManager.eCarStatus CarStatus
        {
            get { return m_CarStatus; }
            set { m_CarStatus = value; }
        }

        public override string ToString()
        {
            return $@"
                        Details:
                        
                Owner Name: {OwnerName}
                Owner Phone: {OwnerPhone}
                Car Status: {CarStatus}

                Vehicle: {Vehicle}";
        }
    }
}
