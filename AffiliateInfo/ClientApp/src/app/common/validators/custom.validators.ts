import { AbstractControl, FormArray } from '@angular/forms';

export function ValidateArrayEmpty(control: AbstractControl) {
  if (control.value && control.value.length > 0) {
    return null;
  }
  return { emptyArray: true };
}


export function ValidateArray100percent(control: FormArray) {
  const pSum = control.value.map(a => parseFloat(a.percentOwnership) ?
    parseFloat(a.percentOwnership) : 0).reduce((a, b) => a + b);
  return (pSum >= 95.00 && pSum <= 100.0) ? null : { incorrectPercentSum: true };
}
