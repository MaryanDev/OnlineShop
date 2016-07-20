(function (angular) {
    angular.module("shopModule")
           .factory("dashboardService", dashboardService);

    dashboardService.$inject = ["$http"]

    function dashboardService($http) {
        var service = {
            getCategories: getCategoriesAjax,
            getProducts: getProductsAjax,
            sendComment: sendCommentAjax
        };

        return service;

        function getCategoriesAjax() {
            var promise = $http.get("GetCategories");
            return promise;
        };

        function getProductsAjax(page, category, minPrice, maxPrice, searchedTitle) {
            var promise = $http({
                method: "GET",
                url: "GetProducts",
                params: {
                    currentPage: page,
                    category: category,
                    minChoiceCost: minPrice,
                    maxChoiceCost: maxPrice,
                    searchedTitle: searchedTitle
                }
            });
            return promise;
        };

        function sendCommentAjax(productId, commentText) {
            var promise = $http.post("AddComment", data = {id: productId, comment: commentText});
            return promise;
        }
    }
})(angular);