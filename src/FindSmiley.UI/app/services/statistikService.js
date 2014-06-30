'use strict';
app.factory('StatistikService', ['$http', 'baseUrl', function ($http, baseUrl) {
    var StatistikService = function () {
        var $this = this;

        $this.test1 = function (searchQuery) {
            return $http({
                url: baseUrl + 'statistik/test1',
                method: 'GET',
            }).then(function (response) {
                return response.data;
            });
        }

        $this.test2 = function (searchQuery) {
            return $http({
                url: baseUrl + 'statistik/test2',
                method: 'GET',
            }).then(function (response) {
                return response.data;
            });
        }

        $this.test3 = function (searchQuery) {
            return $http({
                url: baseUrl + 'statistik/test3',
                method: 'GET',
            }).then(function (response) {
                return response.data;
            });
        }
    }

    return new StatistikService();
}]);