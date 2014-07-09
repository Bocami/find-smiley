'use strict';
app.controller('homeController', ['$scope', '$timeout', 'SearchService', 'geolocation', function ($scope, $timeout, SearchService, geolocation) {
    $scope.searchQuery = {
        keywords: null,
    };

    geolocation.getLocation().then(function (data) {
        $scope.searchQuery.latitude = data.coords.latitude;
        $scope.searchQuery.longitude = data.coords.longitude;
    });

    $scope.timer = undefined;

    $scope.cancelTimer = function () {
        $scope.isWorking = false;

        if ($scope.timer != undefined)
            $timeout.cancel($scope.timer);
    };

    $scope.resetTimer = function() {
        $scope.cancelTimer();

        $scope.timer = $timeout(function () {
            $scope.isWorking = true;
        }, 250);
    };

    $scope.search = function () {
        if ($scope.searchQuery.keywords.length > 0) {

            $scope.resetTimer();

            SearchService.search($scope.searchQuery).then(function (searchResult) {
                $scope.searchResult = searchResult;

                $scope.cancelTimer();
            });
        } else {
            $scope.searchResult = null;
            $scope.isWorking = false;

            $scope.cancelTimer();
        }
    }
}]);