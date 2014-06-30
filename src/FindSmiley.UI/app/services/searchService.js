'use strict';
app.factory('SearchService', ['$http', '$q', 'baseUrl', function ($http, $q, baseUrl) {
    var SearchService = function() {
        var $this = this;

        $this.canceler = null;

        $this.search = function (searchQuery) {

            if ($this.canceler != null)
                $this.canceler.resolve();

            $this.canceler = $q.defer();

            return $http({
                url: baseUrl + 'search',
                method: 'GET',
                params: searchQuery,
                timeout: $this.canceler.promise
            }).then(function (response) {
                $this.canceler = null;

                return response.data;
            });
        }
    }

    return new SearchService();
}]);