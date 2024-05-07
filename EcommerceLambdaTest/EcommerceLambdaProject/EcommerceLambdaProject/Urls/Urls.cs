namespace EcommerceLambdaProject.Urls;

public static class Urls
{

    public static string BASE_URL => "https://ecommerce-playground.lambdatest.io/";
    private static string ROUTE_PREFIX => "index.php?route=";
    private static string RouteUrl(string route) => BASE_URL + ROUTE_PREFIX + route;
    public static string SEARCH_SHOP_PRODUCTS_PAGE => RouteUrl("product/search&search=&limit=100");
    public static string SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(string minPrice, string maxPrice) => RouteUrl($"product/search&limit=100&mz_fp={minPrice}p{maxPrice}");
    public static string RETURN_PRODUCT_PAGE => RouteUrl("account/return/add");
    public static string SUCCESSFUL_RETURN_PRODUCT_PAGE => RouteUrl("account/return/success");
    public static string HOME_PAGE => RouteUrl("common/home");
    public static string CART_PAGE => RouteUrl("checkout/cart");
    public static string CHECKOUT_PAGE => RouteUrl("checkout/checkout");
    public static string LOGIN_PAGE => RouteUrl("account/login");
    public static string REGISTER_PAGE => RouteUrl("account/register");
    public static string WISHLIST_PAGE => RouteUrl("account/wishlist");
    public static string COMPARISON_PAGE => RouteUrl("product/compare");
    public static string SUCCESSFUL_REGISTRATION_PAGE => RouteUrl("account/success");
    public static string FORGOTTEN_PASSWORD_PAGE => RouteUrl("account/forgotten");
    public static string LOGOUT_USER_PAGE => RouteUrl("account/logout");
    public static string ORDER_HISTORY_PAGE => RouteUrl("account/order");
    public static string ORDER_PAGE => RouteUrl("account/order/info");
    public static string ACCOUNT_PAGE => RouteUrl("account/account");
    public static string VOUCHER_PAGE => RouteUrl("account/voucher");
    public static string SUCCESSFUL_VOUCHER_PAGE => RouteUrl("account/voucher/success");
    public static string ADDRESS_BOOK_PAGE => RouteUrl("account/address");
    public static string NEW_ADDRESS_PAGE => RouteUrl("account/address/add");
    public static string SUCCESSFUL_ORDER_PAGE => RouteUrl("checkout/success");
}
