'use strict';

nagApp.controller('PhoneInstanceLookupController',
    function PhoneInstanceLookupController($scope, $routeParams, phoneData) {
        $scope.accountId = $routeParams.accountId;
        $scope.phoneInstanceId = $routeParams.phoneInstanceId;
        $scope.plans = phoneData.getPlans();
        $scope.account = phoneData.getAccount($routeParams.accountId);
        $scope.phoneInstance = phoneData.getPhoneInstance($routeParams.accountId, $routeParams.phoneInstanceId,
            function (phoneInstance) {
                $scope.serialNumber = phoneInstance.serialNumber;
                $scope.phoneNumber = phoneInstance.phoneNumber;
                $scope.phonePlanId = phoneInstance.phonePlan.planId;
            }
        );

        $scope.planSelected = function() {
            console.log("You selected " + $scope.phonePlanId);
        };
    });
