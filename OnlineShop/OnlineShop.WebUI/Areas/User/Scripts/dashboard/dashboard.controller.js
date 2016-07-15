(function (angular) {
    angular.module("shopModule")
           .controller("dashboardCtrl", dashboardCtrl);
    dashboardCtrl.$inject = ["$scope", "dashboardService"];

    function dashboardCtrl($scope, dashboardService) {
        $scope.categories = null;
        $scope.products = null;
        $scope.allPages = null;
        $scope.currentCategory = "All";
        $scope.maxCost = 0;

        function activate() {
            dashboardService.getCategories()
                            .then(function (responce) {
                                $scope.categories = responce.data;
                                console.log($scope.categories);
                            }, function myError(responce) {
                                console.log(responce.statusText)
                            });

            dashboardService.getProducts()
                            .then(function (responce) {
                                $scope.products = responce.data.products;
                                $scope.allPages = responce.data.allPages;
                                $scope.maxCost = responce.data.maxCost;
                                console.log($scope.products);
                            }, function myError(responce) {
                                console.log(responce.statusText);
                            });
        }
        activate();

        $scope.getPage = function (page, category, minPrice, maxPrice, searchedTitle) {
            dashboardService.getProducts(page, category, minPrice, maxPrice, searchedTitle)
                            .then(function (responce) {
                                $scope.products = responce.data.products;
                                $scope.allPages = responce.data.allPages;
                                $scope.maxCost = responce.data.maxCost;
                                console.log($scope.products);
                            }, function myError(responce) {
                                console.log(responce.statusText);
                            });
        };
    }
})(angular);