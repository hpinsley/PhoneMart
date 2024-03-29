﻿'use strict';

nagApp.controller('PhoneInstanceLookupController',

    function PhoneInstanceLookupController($scope, $routeParams, phoneData, $http, $location) {

        $scope.accountId = $routeParams.accountId;
        $scope.phoneInstanceId = $routeParams.phoneInstanceId;
        $scope.plans = phoneData.getPlans();
        $scope.account = phoneData.getAccount($routeParams.accountId);

        //We want the form controls to bind to independent scope variables -- 
        //i.e. not directly to the values in the returned phoneInstance.
        //Since we get the phone instance with a resource.get call, we have
        //to utilitize it's callback so as to set the independent variables
        //only once we have the data.
        
        $scope.phoneInstance = phoneData.getPhoneInstance($routeParams.accountId, $routeParams.phoneInstanceId,
            function (phoneInstance) {
                $scope.serialNumber = phoneInstance.serialNumber;
                $scope.phoneNumber = phoneInstance.phoneNumber;
                $scope.phonePlanId = phoneInstance.phonePlan.planId;
            }
        );

        $scope.cancel = function() {
            $location.path("/accounts/" + $scope.accountId);
        };
        
        $scope.updatePhoneInstance = function (accountId, phoneInstanceId) {
            console.log("Updating phone instance " + phoneInstanceId + " for account " + accountId);

            $http({
                method: "PUT",
                url: nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones/" + phoneInstanceId,
                data: {
                    serialNumber: $scope.serialNumber,
                    phoneNumber: $scope.phoneNumber,
                    phonePlanId: $scope.phonePlanId
                }
            })
            .success(function () {
                $location.path("/accounts/" + accountId);
            })
            .error(function (error, status) {
                alert("We got error " + (error.exceptionMessage || error.message) + " with status " + status);
            });

        };

        $scope.deletePhoneInstance = function(accountId, phoneInstanceId) {
            if (!confirm("Do you really want to delete this phone?")) {
                return;
            }
            $http({
                method: "DELETE",
                url: nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones/" + phoneInstanceId,
            })
            .success(function () {
                $location.path("/accounts/" + accountId);
            })
            .error(function (error, status) {
                alert("We got error " + (error.exceptionMessage || error.message) + " with status " + status);
            });
        };
    });
