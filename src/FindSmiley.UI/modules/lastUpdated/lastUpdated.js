(function(angular, undefined) {
    'use strict';

    var lastUpdatedModule = angular.module('lastUpdatedModule', ['angularMoment']);

    lastUpdatedModule.factory('LastUpdatedService', ['$http', function ($http) {
        var LastUpdatedService = function() {
            this.getLastUpdated = function() {
                return $http({
                    method: 'get',
                    url: 'Api/LastUpdated'
                }).then(function(response) {
                    return response.data;
                });
            };
        };

        return new LastUpdatedService();
    }]);

    lastUpdatedModule.directive('lastUpdated', function() {
        return {
            restrict: 'AE',
            scope: {},
            controller: [
                '$scope', 'LastUpdatedService', function($scope, LastUpdatedService) {
                    LastUpdatedService.getLastUpdated().then(function(lastUpdated) {
                        $scope.lastUpdatedOn = lastUpdated.lastUpdatedOn;
                    });
                }
            ],
            template: '<time class="last-updated-on">{{lastUpdatedOn | amCalendar}}</time>'
        };
    });

})(angular);