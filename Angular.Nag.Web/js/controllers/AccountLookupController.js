'use strict';

nagApp.controller('AccountLookupController',
    function AccountLookupController($scope, $routeParams, phoneData, $location, $http) {
        $scope.accountId = $routeParams.accountId;
        $scope.account = phoneData.getAccount($routeParams.accountId);
        $scope.mode = "SHOW";
        
        $scope.addPhone = function () {
            $location.path("/accounts/" + $routeParams.accountId + "/phones/add");
        };

        $scope.editAccount = function (account) {
            
            //We need to copy the current values to new variables in the scope in case he
            //cancels the update.  The input controls are bound to these variables.
            
            $scope.auFullName = account.accountHolder.fullName;
            $scope.auContactPhoneNumber = account.accountHolder.contactPhoneNumber;
            $scope.auEmailAddress = account.accountHolder.emailAddress;
            $scope.mode = "EDIT";
        };

        $scope.updateAccount = function (accountId) {
            console.log("Updating account " + accountId + " with full name = " + $scope.auFullName + "...");

            $http({
                method: "PUT",
                url: "http://localhost/Angular.Nag.Services/api/accounts/" + accountId,
                data: {
                    fullName: $scope.auFullName,
                    contactPhoneNumber: $scope.auContactPhoneNumber,
                    emailAddress: $scope.auEmailAddress
                }
            })
            .success(function () {
                //If we update the data, reget the account object for redisplay
                $scope.account = phoneData.getAccount($routeParams.accountId);
            })
            .error(function (error) {
                alert("We got error " + error.exceptionMessage);
            });

            $scope.mode = "SHOW";
        };

        $scope.cancelEditAccount = function (accountId) {
            $scope.mode = "SHOW";
        };
    });
