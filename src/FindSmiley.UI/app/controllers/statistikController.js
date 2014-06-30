'use strict';
app.controller('statistikController', ['$scope', 'StatistikService', function ($scope, StatistikService) {
    $scope.Math = window.Math;

    StatistikService.test1().then(function (statistik) {
        $scope.statistik1 = statistik;
    });

    StatistikService.test2().then(function (statistik) {
        $scope.statistik2 = statistik;
    });

    StatistikService.test3().then(function (statistik) {
        $scope.statistik3 = statistik;
    });
}]);