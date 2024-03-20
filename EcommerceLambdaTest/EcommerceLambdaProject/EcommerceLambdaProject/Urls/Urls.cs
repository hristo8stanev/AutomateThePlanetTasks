namespace EcommerceLambdaProject.Urls;
public class Urls
    {
        public string BASE_URL => "https://ecommerce-playground.lambdatest.io/";
        public  string SEARCH_SHOP_PRODUCTS_PAGE => BASE_URL + "index.php?route=product%2Fsearch&search=&limit=100";
        public  string HOME_PAGE => BASE_URL + "index.php?route=common/home";
        public  string SEARCH_PRODUCTS_PAGE => BASE_URL + "index.php?route=product%2Fsearch&search=";
        public  string PRODUCT_PAGE => BASE_URL + "index.php?route=product/product";
        public  string CART_PAGE => BASE_URL + "index.php?route=checkout/cart";
        public  string CHECKOUT_PAGE => BASE_URL + "index.php?route=checkout/checkout";
        public  string LOGIN_PAGE => BASE_URL + "index.php?route=account/login";
        public  string REGISTER_PAGE => BASE_URL + "index.php?route=account/register";
        public  string BLOG_HOME_PAGE => BASE_URL + "index.php?route=extension/maza/blog/home";
        public  string BLOG_ARTICLE_PAGE => BASE_URL + "index.php?route=extension/maza/blog/article&article_id={0}";
        public  string WISHLIST_PAGE => BASE_URL + "index.php?route=account/wishlist";
        public  string COMPARISON_PAGE => BASE_URL + "index.php?route=product/compare";
        public  string SUCCESSFUL_REGISTRATION_PAGE => BASE_URL + "index.php?route=account/success";
        public  string FORGOTTEN_PASSWORD_PAGE => BASE_URL + "index.php?route=account/forgotten";
        public  string ORDER_HISTORY_PAGE => BASE_URL + "index.php?route=account/order";
        public  string ORDER_PAGE => BASE_URL + "index.php?route=account/order/info";
        public  string ACCOUNT_PAGE => BASE_URL + "index.php?route=account/account";
        public  string ADDRESS_BOOK_PAGE => BASE_URL + "index.php?route=account/address";
        public  string NEW_ADDRESS_PAGE => BASE_URL + "index.php?route=account/address/add";
        public  string EDIT_ADDRESS_PAGE => BASE_URL + "index.php?route=account/address/edit";
        public  string SUCCESSFUL_ORDER_PAGE => BASE_URL + "index.php?route=checkout/success";
    
}
