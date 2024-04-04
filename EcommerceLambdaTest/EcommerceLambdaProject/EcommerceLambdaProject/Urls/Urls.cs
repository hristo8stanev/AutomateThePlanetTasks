﻿namespace EcommerceLambdaProject.Urls;
    public static class Urls
    {
        public static string BASE_URL => "https://ecommerce-playground.lambdatest.io/";
        public static string SEARCH_SHOP_PRODUCTS_PAGE => BASE_URL + "index.php?route=product%2Fsearch&search=&limit=100";
        public static string SEARCH_SHOP_PRODUCTS_PAGE_PRICE_RANGE(string minPrice, string maxPrice) => BASE_URL + $"index.php?route=product%2Fsearch&limit=100&mz_fp={minPrice}p{maxPrice}";
        public static string HOME_PAGE => BASE_URL + "index.php?route=common/home";
        public static string CART_PAGE => BASE_URL + "index.php?route=checkout/cart";
        public static string CHECKOUT_PAGE => BASE_URL + "index.php?route=checkout/checkout";
        public static string LOGIN_PAGE => BASE_URL + "index.php?route=account/login";
        public static string REGISTER_PAGE => BASE_URL + "index.php?route=account/register";
        public static string WISHLIST_PAGE => BASE_URL + "index.php?route=account/wishlist";
        public static string COMPARISON_PAGE => BASE_URL + "index.php?route=product/compare";
        public static string SUCCESSFUL_REGISTRATION_PAGE => BASE_URL + "index.php?route=account/success";
        public static string FORGOTTEN_PASSWORD_PAGE => BASE_URL + "index.php?route=account/forgotten";
        public static string LOGOUT_USER_PAGE => BASE_URL + "index.php?route=account/logout";
        public static string ORDER_HISTORY_PAGE => BASE_URL + "index.php?route=account/order";
        public static string ORDER_PAGE => BASE_URL + "index.php?route=account/order/info";
        public static string ACCOUNT_PAGE => BASE_URL + "index.php?route=account/account";
        public static string VOUCHER_PAGE => BASE_URL + "index.php?route=account/voucher";
        public static string SUCCESSFUL_VOUCHER_PAGE => BASE_URL + "index.php?route=account/voucher/success";
        public static string ADDRESS_BOOK_PAGE => BASE_URL + "index.php?route=account/address";
        public static string NEW_ADDRESS_PAGE => BASE_URL + "index.php?route=account/address/add";
        public static string SUCCESSFUL_ORDER_PAGE => BASE_URL + "index.php?route=checkout/success";
    }