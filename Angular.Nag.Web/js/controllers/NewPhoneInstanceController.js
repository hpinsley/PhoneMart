'use strict';

nagApp.controller('NewPhoneInstanceController', function NewPhoneInstanceController($scope, $http, $location, $routeParams, phoneData) {

    $scope.accountId = $routeParams.accountId;
    $scope.phones = phoneData.getPhones();
    $scope.plans = phoneData.getPlans();

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
