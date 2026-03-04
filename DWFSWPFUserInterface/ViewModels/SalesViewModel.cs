using Caliburn.Micro;
using DWFSWPFUserInterface.Library.Api;
using DWFSWPFUserInterface.Library.Helpers;
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
        IProductEndpoint _productEndpoint;                                                  //API 
        IConfigHelper _configHelper;
        private BindingList<ProductModel> _products;                                        //Products List
        private ProductModel _selectedProduct;                                              //Selected Product
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();        //Cart List
        private int _itemQuantity = 1;                                                          //ItemQuantity



        //--------------------------------//
        //Methods
        //--------------------------------//

        //API Connection for Products
        public SalesViewModel(IProductEndpoint productEndpoint, IConfigHelper configHelper)
        {
            _productEndpoint = productEndpoint;
            _configHelper = configHelper;
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
        
        //Selected Product Binding
        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        //Cart List binding
        public BindingList<CartItemModel> Cart
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
                NotifyOfPropertyChange(() => CanAddToCart);
			}
		}

        //SubTotal binding
        public string SubTotal
        {
            get
            {
                //NB: this would be the TOTAL for a tax system like GST where the price is INCLUSIVE of tax
                return CalculateSubTotal().ToString("C");
            }
        }
        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in Cart)
            {
                subTotal += (item.Product.RetailPrice * item.QuantityInCart);
            }
            return subTotal;
        }
        //Calculate Tax
        public string Tax
        {
            get
            {              
                return CalculateTax().ToString("C");
            }
        }

        private decimal CalculateTax()
        {
            decimal taxAmount = 0;
            decimal taxRate = _configHelper.GetTaxRate()/100;


            //foreach (var item in Cart)
            //{
            //    if (item.Product.IsTaxable)
            //    {
            //        //This is for a tax system like GST in where the retail price is INCLUSIVE of the tax
            //        taxAmount += ((item.Product.RetailPrice * item.QuantityInCart)                  // Get's the Total
            //            - (item.Product.RetailPrice * item.QuantityInCart / ( 1 +  taxRate)));        // & subtracts the subtotal


            //        ////This is for a tax system like VAT where the the retail price is NOT INCLUSIVE of the tax
            //        //taxAmount += (item.Product.RetailPrice * item.QuantityInCart * taxRate); 
            //    }
            //}

            //Tax Type VAT
            taxAmount = Cart
                .Where(x => x.Product.IsTaxable)
                .Sum(x => x.Product.RetailPrice * x.QuantityInCart * taxRate);

            return taxAmount;
        }

        public string Total         //Only required if Retail Price is Pre Tax
        {
            get
            {
                decimal total = CalculateSubTotal() + CalculateTax();
                return total.ToString("C");
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
                if(ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;
            }
        }

        //Add items to the cart
        public void AddToCart()
		{
            CartItemModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;

                // HACK - There should be a better way of refreshing the cart display
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                CartItemModel item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }

            
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
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
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
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
