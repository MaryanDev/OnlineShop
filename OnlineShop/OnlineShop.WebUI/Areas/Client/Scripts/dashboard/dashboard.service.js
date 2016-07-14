(function (angular) {
    angular.module("shopModule")
           .factory("dashboardService", dashboardService);

    dashboardService.$inject = ["$http"]

    function dashboardService($http) {
        var service = {
            getCategories: getCategoriesAjax,
            //getProducts: getProductsAjax
        };

        return service;

        function getCategoriesAjax() {
            var promise = $http.get("GetCategories");
            return promise;
        }
    }
})(angular);