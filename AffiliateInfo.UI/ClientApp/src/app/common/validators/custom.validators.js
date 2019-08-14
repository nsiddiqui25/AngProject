"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function ValidateArrayEmpty(control) {
    if (control.value && control.value.length > 0) {
        return null;
    }
    return { emptyArray: true };
}
exports.ValidateArrayEmpty = ValidateArrayEmpty;
function ValidateArray100percent(control) {
    if (control && control.value && control.value.length > 0) {
        var pSum = control.value.map(function (a) { return parseFloat(a.percentOwnership) ?
            parseFloat(a.percentOwnership) : 0; }).reduce(function (a, b) { return a + b; });
        return (pSum >= 95.00 && pSum <= 100.0) ? null : { incorrectPercentSum: true };
    }
}
exports.ValidateArray100percent = ValidateArray100percent;
//# sourceMappingURL=custom.validators.js.map