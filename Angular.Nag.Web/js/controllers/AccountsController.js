'use strict';

nagApp.controller('AccountsController',
    function AccountsController($scope, phoneData) {
        $scope.accounts = phoneData.getAccounts();
    });
