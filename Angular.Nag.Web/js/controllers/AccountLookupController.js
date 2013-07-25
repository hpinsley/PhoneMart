'use strict';

nagApp.controller('AccountLookupController',
    function AccountLookupController($scope, $routeParams) {
        $scope.accountId = $routeParams.accountId;
    });
