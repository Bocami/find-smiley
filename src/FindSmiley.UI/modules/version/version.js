(function (angular, undefined) {
    'use strict';

    var version = angular.module('version', []);

    version.constant('baseUrl', '/Api/');

    version.factory('Version', ['$http', 'baseUrl', function ($http, baseUrl) {
        return {
            getVersion: function () {
                return $http.get(baseUrl + 'Version').then(function (result) {
                    return result.data.version;
                });
            }
        };
    }]);

    version.directive('version', function () {
        return {
            restrict: 'AE',
            controller: ['$scope', 'Version', function ($scope, Version) {
                Version.getVersion().then(function (version) {
                    $scope.version = version;
                });
            }],
            template: '<span class="version"><span>Version {{version.major}}.{{version.minor}}</span></span>'
        };
    });

})(angular);