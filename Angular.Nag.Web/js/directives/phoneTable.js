'use strict';

nagApp.directive('phoneTable', function () {
    return {
        restrict: 'E',
        templateUrl: '/templates/directives/phoneTable.html',
        replace: true,
        scope: {
            phones: "="
        }
    };
});
