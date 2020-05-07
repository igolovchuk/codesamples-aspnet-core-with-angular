import { ErrorMessage } from 'ng-bootstrap-form-validation';
import { FormGroup } from '@angular/forms';

export const CUSTOM_ERRORS: ErrorMessage[] = [
  {
    error: 'required',
    format: requiredFormat
  },
  {
    error: 'minlength',
    format: minLengthFormat
  },
  {
    error: 'maxlength',
    format: maxLengthFormat
  },
  {
    error: 'min',
    format: minFormat
  },
  {
    error: 'max',
    format: maxFormat
  },
  {
    error: 'matchPassword',
    format: matchPasswordFormat
  },
  {
    error: 'email',
    format: emailFormat
  },
  {
    error: 'uniqueViolation',
    format: uniqueViolationFormat
  }
];

export const LOGIN_ERRORS: ErrorMessage[] = [
  ...CUSTOM_ERRORS,
  {
    error: 'pattern',
    format: loginPatternFormat
  }
];

export const NAME_FIELD_ERRORS: ErrorMessage[] = [
  ...CUSTOM_ERRORS,
  {
    error: 'pattern',
    format: nameFieldFormat
  }
];

export const NUM_FIELD_ERRORS: ErrorMessage[] = [
  ...CUSTOM_ERRORS,
  {
    error: 'pattern',
    format: numberOnlyPatternFormat
  }
];

export const LET_NUM_FIELD_ERRORS: ErrorMessage[] = [
  ...CUSTOM_ERRORS,
  {
    error: 'pattern',
    format: letterAndNumberOnlyPatternFormat
  }
];

export const PDF_FILE_ERRORS: ErrorMessage[] =
[
  ...CUSTOM_ERRORS,
  {
    error: 'PDFFormat',
    format: PDFFormat
  }
];

export function requiredFormat(label: string, error: any): string {
  return `Поле "${label}" є обов'язковим`;
}

export function minLengthFormat(label: string, error: any): string {
  return `Мінімальна довжина поля - ${error.requiredLength}`;
}

export function maxLengthFormat(label: string, error: any): string {
  return `Максимальна довжина поля - ${error.requiredLength}`;
}

export function minFormat(label: string, error: any): string {
  return `Мінімальне значення поля - ${error.min}`;
}

export function maxFormat(label: string, error: any): string {
  return `Максимальне значення поля - ${error.max}`;
}

export function matchPasswordFormat(label: string, error: any): string {
  return 'Паролі не збігаються';
}

export function patternFormat(label: string, error: any): string {
  return 'Не правильний формат вводу';
}

export function loginPatternFormat(label: string, error: any): string {
  return 'Дозволено тільки букви латинського алфавіту та цифри';
}

export function numberOnlyPatternFormat(label: string, error: any): string {
  return 'Дозволено тільки цифри';
}

export function letterAndNumberOnlyPatternFormat(label: string, error: any): string {
  return 'Дозволено тільки букви та цифри';
}

export function nameFieldFormat(label: string, error: any): string {
  return `Дозволено тільки букви, дефіс та апостроф всередині слова`;
}

export function emailFormat(label: string, error: any): string {
  return 'Невірний формат e-mail адреси. Введіть вірний формат, наприклад email@gmail.com.';
}

export function uniqueViolationFormat(label: string, error: any): string {
  return `Таке значення поля "${label}" вже існує. Спробуйте інше`;
}

export function PDFFormat(label: string, error: any): string {
  return 'Потрібно вибрати файл типу PDF';
}

export function matchPassword(form: FormGroup) {
  const { password, confirmPassword } = form.value;
  if (password !== confirmPassword) {
    form.get('confirmPassword').setErrors({ matchPassword: true });
  } else {
    return null;
  }
}

export function malfunctionSelectedValidator(form: FormGroup) {
  const { malfunctionGroup, malfunctionSubgroup, malfunction } = form.value;
  if (malfunctionSubgroup && !malfunction) {
    form.get('malfunction').setErrors({ required: true });
  }
  if (malfunctionGroup && !malfunctionSubgroup) {
    form.get('malfunctionSubgroup').setErrors({ required: true });
  }
}
