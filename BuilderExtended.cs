using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder1
{
    class Program
    {
        public class Order
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Adress { get; set; }
            public string ZipCode { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public Order (Builder builder)
            {
                this.Firstname = builder.Firstname;
                this.Lastname = builder.Lastname;
                this.Country = builder.Country;
                this.City = builder.City;
                this.Adress = builder.Adress;
                this.ZipCode = builder.ZipCode;
                this.Email = builder.Email;
                this.PhoneNumber = builder.PhoneNumber;
            }

            public class Builder
            {
                internal string Firstname { get; set; }
                internal string Lastname { get; set; }
                internal string Country { get; set; }
                internal string City { get; set; }
                internal string Adress { get; set; }
                internal string ZipCode { get; set; }
                internal string Email { get; set; }
                internal string PhoneNumber { get; set; }

                public Builder WithFirstname(string firstname)
                {
                    this.Firstname = firstname;
                    return this;
                }

                public Builder WithLastname(string lastname)
                {
                    this.Lastname = lastname;
                    return this;
                }

                public Builder WithCountry(string country)
                {
                    this.Country = country;
                    return this;
                }

                public Builder WithCity(string city)
                {
                    this.City = city;
                    return this;
                }

                public Builder WithAdress(string adress)
                {
                    this.Adress = adress;
                    return this;
                }

                public Builder WithZipCode(string zipcode)
                {
                    this.ZipCode = zipcode;
                    return this;
                }

                public Builder WithEmail(string email)
                {
                    this.Email = email;
                    return this;
                }

                public Builder WithPhoneNumber(string phone)
                {
                    this.PhoneNumber = phone;
                    return this;
                }

                public Order Build()
                {
                    return new Order(this);
                }
            }

        }

        static void Main(string[] args)
        {
            Order order = new Order.Builder()
                .WithFirstname("Marcin")
                .WithLastname("Kowalski")
                .WithEmail("kowal@wp.pl")
                .WithCountry("Polska")
                .WithCity("Krosno")
                .WithAdress("Mickiewicza 45/5")
                .WithZipCode("38-400")
                .WithPhoneNumber("765231428")
                .Build();
        }
    }
}
