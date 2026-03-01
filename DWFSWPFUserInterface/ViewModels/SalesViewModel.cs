using Caliburn.Micro;
using DWFSWPFUserInterface.Library.Api;
using DWFSWPFUserInterface.Library.Models;
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

        //Dependancy injection private Backing fields
        IProductEndpoint _productEndpoint;              //API 
        private BindingList<ProductModel> _products;    //Products List
        private BindingList<ProductModel> _cart;        //Cart List
        private int _itemQuantity;                      //ItemQuantity



        //--------------------------------//
        //Methods
        //--------------------------------//

        //API Connection for Products
        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        //Load Product List
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        //Wait for product listings
        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        //Products List binding
        public BindingList<ProductModel> Products
		{
			get { return _products; }
			set 
			{ 
				_products = value; 
				NotifyOfPropertyChange(() => Products);
			}
		}

        //Cart List binding
        public BindingList<ProductModel> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value; 
                NotifyOfPropertyChange(() => Cart);
            }
        }

        //Item Quantity	binding
        public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{ 
				_itemQuantity = value; 
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}

        //SubTotal binding
        public string Subtotal
        {
            get
            {
                //  TODO    Replace with calculation
                return "$0.00";
            }
        }

        //Add to Cart Button binding
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

        //Remove from cart button binding
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

        //Checkout binding
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
    }
}
