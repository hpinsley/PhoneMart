'use strict';

var nagApp = angular.module('nagApp', ['ngResource']);

nagApp.config(function ($routeProvider) {
    $routeProvider
        .when('/phones',
            {
                controller: 'PhoneController',
                templateUrl: 'templates/phones.html'
            })
        .when('/plans',
            {
                controller: 'PlansController',
                templateUrl: 'templates/plans.html'
            })
        .otherwise({ redirectTo: '/phones' });
});