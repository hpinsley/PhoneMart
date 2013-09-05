﻿'use strict';

nagApp.controller('NewPhoneInstanceController', function NewPhoneInstanceController($scope, $http, $location, $routeParams, phoneData) {

    $scope.accountId = $routeParams.accountId;
    $scope.phones = phoneData.getPhones();
    $scope.plans = phoneData.getPlans();

    $scope.$watch("phoneId", function () {
        if (!$scope.phoneId)
            return;
        
        alert("Phone id changed to " + $scope.phoneId);
        //Since the phone selection changed, we have to also change
        //the plan dropdown so it includes only the plans associated
        //with the phone model.
    });
    
    $scope.cancel = function() {
        $location.path("/accounts/" + $scope.accountId);
    };
    
    $scope.addPhone = function(accountId) {
        console.log("adding phone for account " + accountId + " with phoneId " + $scope.phoneId + " and phonePlanId " + $scope.phonePlanId);

        $http({
            method: "POST",
            url: nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones",
            data: {
                accountId: accountId,
                phoneId: $scope.phoneId,
                serialNumber: $scope.serialNumber,
                phoneNumber: $scope.phoneNumber,
                phonePlanId: $scope.phonePlanId
            }
        })
        .success(function () {
            $location.path("/accounts/" + accountId);
        })
        .error(function (error) {
            alert("We got error " + error.exceptionMessage);
        });

    };
   
});
