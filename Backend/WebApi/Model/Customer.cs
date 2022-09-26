using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Customer
    {


        public Customer(int id, string? name, string? address, string? policyType, string? insurerName, double? premium)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.policyType = policyType;
            this.insurerName = insurerName;
            this.premium = premium;
        }

        public Customer()
        {

        }

        [Key]
        public int id { get; set; }

        public string? name { get; set; }

        public string? address { get; set; }

        public string? policyType { get; set; }

        public string? insurerName { get; set; }

        public double? premium { get; set; }

    }
}