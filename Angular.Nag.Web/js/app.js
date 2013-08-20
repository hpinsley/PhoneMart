'use strict';

var nagApp = angular.module('nagApp', ['ngResource']);

nagApp.getServicesRoot = function() {
    return "http://localhost/Angular.Nag.Services";
};

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

        .when('/phones/:phoneId',
            {
                controller: 'PhoneLookupController',
                templateUrl: 'templates/phone.html'
            })

        .when('/plans',
            {
                controller: 'PlansController',
                templateUrl: 'templates/plans.html'
            })

        .when('/plans/add',
            {
                controller: 'NewPlanController',
                templateUrl: 'templates/newPlan.html'
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

        .when('/accounts/:accountId/phones/:phoneInstanceId',
            {
                controller: 'PhoneInstanceLookupController',
                templateUrl: 'templates/phoneInstance.html'
            })

        .otherwise({ redirectTo: '/phones' });
});