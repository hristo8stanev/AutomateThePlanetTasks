namespace EcommerceLambdaProject.Urls
{
    public static class Url
    {
        public static string BASE_URL => "https://ecommerce-playground.lambdatest.io/";
        public static string SEARCH_SHOP_PRODUCTS_PAGE => BASE_URL + "index.php?route=product%2Fsearch&search=&limit=100";
        public static string HOME_PAGE => BASE_URL + "index.php?route=common/home";
        public static string SEARCH_PRODUCTS_PAGE => BASE_URL + "index.php?route=product%2Fsearch&search=";
        public static string PRODUCT_PAGE => BASE_URL + "index.php?route=product/product";
        public static string CART_PAGE => BASE_URL + "index.php?route=checkout/cart";
        public static string CHECKOUT_PAGE => BASE_URL + "index.php?route=checkout/checkout";
        public static string LOGIN_PAGE => BASE_URL + "index.php?route=account/login";
        public static string REGISTER_PAGE => BASE_URL + "index.php?route=account/register";
        public static string BLOG_HOME_PAGE => BASE_URL + "index.php?route=extension/maza/blog/home";
        public static string BLOG_ARTICLE_PAGE => BASE_URL + "index.php?route=extension/maza/blog/article&article_id={0}";
        public static string WISHLIST_PAGE => BASE_URL + "index.php?route=account/wishlist";
        public static string COMPARISON_PAGE => BASE_URL + "index.php?route=product/compare";
        public static string SUCCESSFUL_REGISTRATION_PAGE => BASE_URL + "index.php?route=account/success";
        public static string FORGOTTEN_PASSWORD_PAGE => BASE_URL + "index.php?route=account/forgotten";
        public static string ORDER_HISTORY_PAGE => BASE_URL + "index.php?route=account/order";
        public static string ORDER_PAGE => BASE_URL + "index.php?route=account/order/info";
        public static string ACCOUNT_PAGE => BASE_URL + "index.php?route=account/account";
        public static string ADDRESS_BOOK_PAGE => BASE_URL + "index.php?route=account/address";
        public static string NEW_ADDRESS_PAGE => BASE_URL + "index.php?route=account/address/add";
        public static string EDIT_ADDRESS_PAGE => BASE_URL + "index.php?route=account/address/edit";
        public static string SUCCESSFUL_ORDER_PAGE => BASE_URL + "index.php?route=checkout/success";
    }
}
