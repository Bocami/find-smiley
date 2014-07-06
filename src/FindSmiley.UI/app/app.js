'use strict';
var app = angular.module('app', ['ngRoute', 'angularMoment', 'version', 'geolocation']);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/statistik", {
        controller: "statistikController",
        templateUrl: "/app/views/statistik.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.constant('baseUrl', '/api/');

app.run(function (amMoment) {
    amMoment.changeLanguage('da');
});