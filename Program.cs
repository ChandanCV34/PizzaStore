using PizzaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore
{

    class Program
    {
       readonly PizzastoreContext context;
        List<Pizza> Pizzas;
       readonly List<Topping> toppings;
       public List<Order> orders;
       public List<OrdersDetail> ordersDetails;
       readonly List<Pizza> delta;
       readonly OrderItemsDetail top;
       public OrdersDetail deta;
       readonly Order ord ;
       readonly User user;
        int price = 0;
        int b = 0;
       readonly string msg ="Ready";
        public Program()
        {
            user = new User();
            ord = new Order();
            ordersDetails = new List<OrdersDetail>();
            context = new PizzastoreContext();
            orders = new List<Order>();
            Pizzas = new List<Pizza>();
            top = new OrderItemsDetail();
            deta = new OrdersDetail();
            delta = new List<Pizza>();
            toppings = new List<Topping>();  
        }
        /// <summary>
        /// Menu Function Displays The User Login and Registration Option
        /// </summary>
        void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("--------WELCOME TO PIZZA ODERING STORE--------");
                Console.WriteLine( "1. Login");
                Console.WriteLine(" 2.Register");
                Console.WriteLine( " 3. Exit ");
                Console.WriteLine("Please Enter Your Choice");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception )
                {

                    Console.WriteLine( "Please Enter The Number Format");
                    Console.WriteLine("Please Enter Your Choice");

                    choice = Convert.ToInt32(Console.ReadLine());

                }
             
                switch (choice)
                {
                    case 1:
                        UserLogin();
                        break;
                    case 2:
                        UsersRegisteration();
                        break;

                    default:
                        Console.WriteLine("!! BYE BYE ENJOY YOUR DAY !!");
                        break;
                }

            } while (choice!=3);
        }
        /// <summary>
        /// In UserRegisteration Where the user can register to there Account by providing the needed credential
        /// </summary>
        void UsersRegisteration()
        {
           // User user = new User ();
            Console.WriteLine("Please Enter Your Email Addres");
            user.UserEmail = Console.ReadLine();

            Console.WriteLine("Please Enter Your Name");
            user.UserName = Console.ReadLine();

            Console.WriteLine("Please Enter Your Password");
            user.UserPassword = Console.ReadLine();


            Console.WriteLine("Please Enter Your Address");
            user.UserAddress = Console.ReadLine();


            Console.WriteLine("Please Enter Your Phone Number");
            user.PhoneNo = Console.ReadLine();


            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("User  Succesfully  Registered ");
        }
        /// <summary>
        /// Onces The Registration process is compeleted The user must enter is email_id and Password for login process
        /// </summary>
     public  void UserLogin()
        {

         //   string userchoice;
            //OrdersDetail deta = new ();
            orders = new List<Order>();
            Pizzas = new List<Pizza>();
          //  Pizza piz = new Pizza();
           // Order ord = new Order();
            // string b = UserLogin();
           // OrderItemsDetail ordit = new OrderItemsDetail();
            // Console.WriteLine(z);
            ////
            
            Console.WriteLine("Enter the Email ID");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            //Order ord = new Order();
            bool status = false;
            foreach (var item in context.Users)
            {

                if (email == item.UserEmail && password == item.UserPassword)
                {

                    Console.WriteLine($"HIIIII!!!! {item.UserName} WELCOME TO  JUST PIZZA!");
                    //PizzaLists();
                    ord.UserEmail = item.UserEmail;
                    // orders.Add(ord);
                    email = item.UserEmail;
                    
                    status = true;
                    //PizzaLists();
                    break;
                    


                }

            }
           
            if (status == false)
            {
                Console.WriteLine("Please enter the valid user name or password");
                Console.WriteLine("Please register the user before login");
                Console.WriteLine("______________________");
                
            }
            //PizzaLists();
            //pizzaorder();
            if (status == true)
            {
                
                NewOrder();
            }
            //foreach (var item in Pizzas)
            //{
            //    deta.PizzaNumber = item.PizzaNumber;
            ////    Console.WriteLine(deta.PizzaNumber);
            //}
            //foreach (var item in context.Orders)
            //{
            //    deta.OrderId = item.OrderId;

            //}
            




        }
        /// <summary>
        /// NewOrder function is used to carry the  ordering process 
        /// </summary>

        public void NewOrder()
        {
            OrdersDetail deta = new();
            int choice;
            PizzaLists();
            Console.WriteLine(" Enter The Pizza of your Choice");
            // int choice = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                 choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter In Numerical Form");
                Console.WriteLine(" Enter The Pizza of your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            
            bool status = false;
            foreach (var item in context.Pizzas)
            {
                if (item.PizzaNumber == choice)
                {
                    
                    status = true;
                    Console.WriteLine($" You have Selected {item.Name } for ${item.Price} ");
                    
                   
                        ord.TotalAmount = price + item.Price;
                       price = (int)ord.TotalAmount;
                   // ord.TotalAmount = price;
                    delta.Add(item);
                    Pizzas.Add(item);   
                    ord.Status = msg;
                    deta.PizzaNumber = choice;
       
                }
            }
            foreach (var item in Pizzas)
            {
                deta.PizzaNumber = item.PizzaNumber;
               

            }
            foreach (var item in context.Orders)
            {
                deta.OrderId = item.OrderId;
                deta.OrderId++;

            }
            try
            {
                context.OrdersDetails.Add(deta);
                context.SaveChanges();
            }
            catch (Exception )
            {

                Console.WriteLine("pizaa added to cart");
            }





            while (status==true)
            {
                Console.WriteLine("Do you want to add  a item");
                Console.WriteLine("Please Press T for Toppings");
                Console.WriteLine("Please Press Y to Add Some More Pizzas To The cart");
                Console.WriteLine("Please Press Any Key To Exit And Pay The Bill");
                string ch = Console.ReadLine().ToLower();
                if (ch == "y")
                {
                    NewOrder();
                    break;
                }
                else if (ch == "t")
                {
                    Topps();
                    break;
                }
                else
                {
                    Bill();
                    //status = false;
                    break;
                }
               
           
            
            
            }

            //foreach (var item in context.Orders)
            //{
            //    deta.OrderId = item.OrderId;

            //}

            //try
            //{
            //    context.OrdersDetails.Add(deta);
            //    context.SaveChanges();
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
        }

        public void PizzaLists()
        {
            try
            {
                Console.WriteLine("  The following are the pizza that are available for ordering");


                Console.WriteLine("Number\t\tName\t\tPrice\t\tType");
                foreach (var item in context.Pizzas)
                {
                    Console.WriteLine($"{item.PizzaNumber}\t\t{item.Name }\t{item.Price}\t\t{item.Type}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
}

        public void Topps()
        {
            string userchoice;
            Console.WriteLine(" Do You Want  Topping ?");
            Console.WriteLine("Please press Y to Add Toppings");
            Console.WriteLine("Please press O to Add Some more Pizzas");
            Console.WriteLine("Please press E to Generate Your Bill and exit");
            userchoice = Console.ReadLine().ToLower(); 
            switch (userchoice)
            {
                case "y":
                    Toppings();
                    break;
                case "o":
                    Console.WriteLine("Do you want to purchase once again");
                    NewOrder();
                    
                    break;
                case "e":
                    Bill();
                    break;
                   

                default:
                    break;
            }

        }
        public int Toppings()
        {
            
            Console.WriteLine("\nThe Toppings available are:");
            Console.WriteLine("______________________");
            Console.WriteLine("Number\tName\tPrice");
            Console.WriteLine("______________________");
            foreach (var item in context.Toppings)
            {

                Console.WriteLine($"{item.ToppingsNumber}\t{item.Name }\t{item.Price}");


            }
            Console.WriteLine("______________________");
           int b= ToppingOrders();
            
            return b;


        }

       public  int ToppingOrders()
        {
            // List<Topping> tops = new List<Topping>();
            int choice;
            Console.WriteLine();
            Console.WriteLine("  Please Select the topping");
           // choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Please enter in Numerical Form");
                Console.WriteLine("  Please Select the topping");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            foreach (var item in context.Toppings)
            {
                if (item.ToppingsNumber == choice)
                {
                    Console.WriteLine($" You have Selected {item.Name } for ${item.Price} ");

                    top.ToppingsNumber = choice;
                    toppings.Add(item);
                   
                    b = (int) item.Price;    
                } 
            }
           

            Topps();
            //foreach (var item in context.OrdersDetails)
            //{
            //    top.ItemNumber = item.ItemNumber;
            //}

            //try
            //{
            //    context.OrderItemsDetails.Add(top);
            //    context.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}


            return b;
        }

        public void Bill()
        {
            Console.WriteLine("Your Order Sumary is ");
            Console.WriteLine("_______________________");
            Console.WriteLine(" Selected Pizza ");
            Console.WriteLine("_______________________");

            Console.WriteLine("PizzaName\tPrice");
            Console.WriteLine("----------------------");
            foreach (var item in Pizzas)
            {

                Console.WriteLine($"{item.Name}\t{item.Price}");

            }
            Console.WriteLine("_______________________");
            Console.WriteLine(" Extra Toppings Pizza ");
            Console.WriteLine("_______________________");
            Console.WriteLine("ToppingsName\tPrice");
            Console.WriteLine("----------------------");
            foreach (var item in toppings)
            {

                Console.WriteLine($"{item.Name}\t\t{item.Price}");
                // ord.TotalAmount = ord.TotalAmount + item.Price;
                ord.TotalAmount  += item.Price;

            }
            Console.WriteLine("----------------------");

            Console.WriteLine("Total Amount  : "+ord.TotalAmount);

            Console.WriteLine("----------------------");

            if (ord.TotalAmount < 400)
            {
                ord.DeliveryCharges = ord.TotalAmount + 50;
                Console.WriteLine(" Extra $50 For Delivery Charge");
                Console.WriteLine("YOUR TOTAL BILL TO PAY  IS : \t" + ord.DeliveryCharges);



            }
            else
            {
                ord.DeliveryCharges = ord.TotalAmount + 2;
                Console.WriteLine(" Extra $2 For Delivery Charge");
                Console.WriteLine("YOUR TOTAL BILL TO PAY  IS : \t" + ord.DeliveryCharges);
            }
            try
            {
                context.Orders.Add(ord);
                context.SaveChanges();
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);

            }
            //foreach (var item in Pizzas)
            //{
            //    deta.PizzaNumber = item.PizzaNumber;
            //    Console.WriteLine(deta.PizzaNumber);

            //}
            //foreach (var item in context.Orders)
            //{
            //    deta.OrderId = item.OrderId;

            //}
            //try
            //{
            //    context.OrdersDetails.Add(deta);
            //    context.SaveChanges();
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}

            foreach (var item in context.OrdersDetails)
            {
                top.ItemNumber = item.ItemNumber;
            }
            foreach (var item in toppings)
            {
                top.ToppingsNumber = item.ToppingsNumber;
            }


            try
            {
                context.OrderItemsDetails.Add(top);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main()
        {
            new Program().Menu();
            //Program pro = new Program();
            // pro.Menu();
        }
    }
}
