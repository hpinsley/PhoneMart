'use strict';

var nagApp = angular.module('nagApp', ['ngResource']);

nagApp.config(function ($routeProvider) {
    $routeProvider
        .when('/phones',
            {
                controller: 'PhoneController',
                templateUrl: 'templates/phones.html'
            })

        .when('/phones/add',
            {
                controller: 'NewPhoneController',
                templateUrl: 'templates/newPhone.html'
            })

        .when('/plans',
            {
                controller: 'PlansController',
                templateUrl: 'templates/plans.html'
            })

        .when('/plans/:planId',
            {
                controller: 'PlanLookupController',
                templateUrl: 'templates/plan.html'
            })

        .when('/accounts',
            {
                controller: 'AccountsController',
                templateUrl: 'templates/accounts.html'
            })

        .when('/accounts/add',
            {
                controller: 'NewAccountController',
                templateUrl: 'templates/newAccount.html'
            })

        .when('/accounts/:accountId',
            {
                controller: 'AccountLookupController',
                templateUrl: 'templates/account.html'
            })

        .when('/accounts/:accountId/phones/add',
            {
                controller: 'NewPhoneInstanceController',
                templateUrl: 'templates/newPhoneInstance.html'
            })

        .otherwise({ redirectTo: '/phones' });
});