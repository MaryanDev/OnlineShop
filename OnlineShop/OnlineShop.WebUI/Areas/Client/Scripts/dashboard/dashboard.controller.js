(function (angular) {
    angular.module("shopModule")
           .controller("dashboardCtrl", dashboardCtrl);
    dashboardCtrl.$inject = ["$scope", "dashboardService"];

    function dashboardCtrl($scope, dashboardService) {
        $scope.categories = null;

        function activate() {
            dashboardService.getCategories()
                            .then(function (responce) {
                                $scope.categories = responce.data;
                                console.log($scope.categories);
                            }, function myError(responce) {
                                console.log(responce.statusText)
                            });
        }
        activate();
    }
})(angular);