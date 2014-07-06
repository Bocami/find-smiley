'use strict';
app.controller('homeController', ['$scope', 'SearchService', 'geolocation', function ($scope, SearchService, geolocation) {
    $scope.searchQuery = {
        keywords: null,
    };

    geolocation.getLocation().then(function (data) {
        $scope.searchQuery.latitude = data.coords.latitude;
        $scope.searchQuery.longitude = data.coords.longitude;
    });

    $scope.search = function () {
        if ($scope.searchQuery.keywords.length > 0) {
            SearchService.search($scope.searchQuery).then(function (searchResult) {
                $scope.searchResult = searchResult;
            });
        } else {
            $scope.searchResult = null;
        }
    }
}]);