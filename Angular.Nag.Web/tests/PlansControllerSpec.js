describe("PlansController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        mockPhoneData = sinon.stub(
            { getPlans: function () {}}
        );
    }));

    it("plansController should return obtain phone plans and set it on the scope", function () {

        var mockPlans = {};
        var ctrl = $controllerConstructor('PlansController',
            { $scope: scope, $location: {}, phoneData: mockPhoneData });
        mockPhoneData.getplans.returns(mockPlans);
        expect($scope.plans).toBe(mockPlans);
    });

});