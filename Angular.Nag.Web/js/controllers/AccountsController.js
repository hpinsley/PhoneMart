'use strict';

nagApp.controller('AccountsController',
    function AccountsController($scope, phoneData, $location) {
        $scope.accounts = phoneData.getAccounts();

        $scope.addAccount = function () {
            $location.path("/accounts/add");
        };
    });
