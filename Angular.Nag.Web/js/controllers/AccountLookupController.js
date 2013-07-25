'use strict';

nagApp.controller('AccountLookupController',
    function AccountLookupController($scope, $routeParams, phoneData) {
        $scope.accountId = $routeParams.accountId;
        $scope.account = phoneData.getAccount($routeParams.accountId);

    });
