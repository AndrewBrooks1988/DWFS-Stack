using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFSWPFUserInterface.ViewModels
{
    public class SalesViewModel : Screen
    {

        //Private Backing fields
		private BindingList<string> _products;
        private BindingList<string> _cart;
        private int _itemQuantity;

        //--------------------------------//
        //Public methods
        //--------------------------------//

        //Products
        public BindingList<string> Products
		{
			get { return _products; }
			set 
			{ 
				_products = value; 
				NotifyOfPropertyChange(() => Products);
			}
		}
        //--------------------------------

        //Cart
        public BindingList<string> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value; 
                NotifyOfPropertyChange(() => Cart);
            }
        }
        //--------------------------------

        //Item Quantity	
        public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{ 
				_itemQuantity = value; 
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}
        //--------------------------------

        //SubTotal
        public string Subtotal
        {
            get
            {
                //  TODO    Replace with calculation
                return "$0.00";
            }
        }
        //--------------------------------

        //Add to Cart Button
        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected

				//Make sure there is an item quatity

                return output;
            }
        }

        public void AddToCart()
		{

		}
        //--------------------------------

        //Remove from cart button
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected


                return output;
            }
        }

        public void RemoveFromCart()
        {

        }
        //--------------------------------

        //Checkout
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //Make sure something is in the cart


                return output;
            }
        }

        public void CheckOut()
        {

        }
        //--------------------------------
    }
}
