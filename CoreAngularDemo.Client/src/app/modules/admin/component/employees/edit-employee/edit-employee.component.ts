import { Component, Output, EventEmitter, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { NAME_FIELD_ERRORS } from 'src/app/custom-errors';
import { Employee } from 'src/app/modules/shared/models/employee';
import { Post } from 'src/app/modules/shared/models/post';
import { PostService } from 'src/app/modules/shared/services/post.service';
import { EmployeeService } from 'src/app/modules/shared/services/employee.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {
  private readonly stringFieldValidators: Validators[] = [
    Validators.minLength(0),
    Validators.maxLength(30),
    Validators.pattern(/^[A-Za-zА-Яа-яЄєІіЇїҐґ\-\']+$/)
  ];
  readonly customFieldErrors = NAME_FIELD_ERRORS;

  @Output() editEmployee = new EventEmitter<Employee>();
  @Input()
  set employee(employee: Employee) {
    if(!employee)
    {
      return;
    }
    this.selectedEmployee=new Employee(employee);
    if(this.employeeForm)
    {
      this.setUpForm();
    }
  }


  employeeForm: FormGroup;
  posts: Post[] = [];
  selectedEmployee: Employee;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private postService: PostService,
    private toast: ToastrService
  ) {}

  ngOnInit() {
    this.setUpForm();
    this.loadEntities();
  }

  onSubmit() {
    if (this.employeeForm.invalid) {
      return;
    }

    this.updateEmployee();
    this.setUpForm();
  }

  clickSubmit(button: HTMLButtonElement) {
    button.click();
  }

  closeModal() {
    this.setUpForm();
  }

  comparePosts(post: Post, otherPost: Post): boolean {
    return post && otherPost ? post.id === otherPost.id : post === otherPost;
  }

  private loadEntities() {
    this.postService.getEntities().subscribe(posts => (this.posts = posts));
  }

  private setUpForm() {
    this.employeeForm = this.fb.group({
      boardNumber: [
        this.selectedEmployee && this.selectedEmployee.boardNumber,
        [Validators.required, Validators.min(1), Validators.max(1000000000)]
      ],
      lastName: [this.selectedEmployee && this.selectedEmployee.lastName, this.stringFieldValidators],
      firstName: [this.selectedEmployee && this.selectedEmployee.firstName, this.stringFieldValidators],
      middleName: [this.selectedEmployee && this.selectedEmployee.middleName, this.stringFieldValidators],
      shortName: [this.selectedEmployee && this.selectedEmployee.shortName, [...this.stringFieldValidators, Validators.required]],
      post: [this.selectedEmployee && this.selectedEmployee.post, Validators.required]
    });
  }

  private updateEmployee() {
    const employee = new Employee({ ...this.selectedEmployee, ...this.formValue });
    this.employeeService
      .updateEntity(employee)
      .subscribe(
        updatedEmployee => this.editEmployee.next(updatedEmployee),
        _ => this.toast.error('Не вдалось оновити працівника', 'Помилка оновлення працівника')
      );
  }

  private get formValue() {
    return this.employeeForm.value;
  }
}
