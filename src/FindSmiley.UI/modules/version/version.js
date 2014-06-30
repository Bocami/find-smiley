(function (angular, undefined) {
    'use strict';

    var version = angular.module('version', []);

    version.constant('baseUrl', '/api/');

    version.factory('Version', ['$http', 'baseUrl', function ($http, baseUrl) {
        return {
            getVersion: function () {
                return $http.get(baseUrl + 'version').then(function (result) {
                    return result.data;
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
                    console.log(version);
                });
            }],
            template: '<span class="version"><span>Version {{version.major}}.{{version.minor}}<span class="hidden-xs">.{{version.revision}}.{{version.build}}</span></span>'
        };
    });

})(angular);