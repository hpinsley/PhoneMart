describe("PlansController", function () {

    var $scope, ctrl;

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        ctrl = $controller("PlansController", { $scope: $scope });
    }));

    it("should setup controller properly", function () {
        expect(true).toBe(true);
        expect(nagApp).toBeDefined();
        expect($scope).toBeDefined();
        expect(ctrl).toBeDefined();
    });

});