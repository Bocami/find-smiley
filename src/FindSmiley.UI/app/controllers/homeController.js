'use strict';
app.controller('homeController', ['$scope', 'SearchService', function ($scope, SearchService) {
    $scope.searchQuery = {
        keywords: null
    };

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