'use strict';
var app = angular.module('app', ['ngRoute', 'angularMoment', 'version', 'geolocation', 'lastUpdatedModule', 'releaseModule']);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/udgivelsesnotater", {
        controller: "releaseController",
        templateUrl: "/modules/release/release.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.constant('baseUrl', '/api/');

app.run(function (amMoment) {
    amMoment.changeLanguage('da');
});