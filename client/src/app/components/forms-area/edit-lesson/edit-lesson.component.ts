import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LessonModel } from '../../../models/lesson.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseManagerService } from '../../../services/course-manager.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-lesson',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './edit-lesson.component.html',
  styleUrl: './edit-lesson.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditLessonComponent {
  lessonForm!: FormGroup;
  lesson!: LessonModel;

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private CourseManagerService: CourseManagerService
  ) {
    this.lessonForm = this.formBuilder.group({
      title: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(200),
        ],
      ],
      description: ['', [Validators.maxLength(2000)]],
      videoUrl: ['', [Validators.required, Validators.pattern('https?://.+')]],
    });
  }

  async send() {
    const id = this.route.snapshot.paramMap.get('id');
    const courseId = this.route.snapshot.queryParamMap.get('courseId');

    const lesson: LessonModel = {
      id: id!,
      title: this.lessonForm.get('title')!.value,
      description: this.lessonForm.get('description')!.value,
      videoUrl: this.lessonForm.get('videoUrl')!.value,
      courseId: courseId!,
    };

    this.CourseManagerService.updateLesson(lesson.courseId, lesson).subscribe({
      next: () => {
        this.toastr.success('Lesson has been successfully updated!');
        this.router.navigate(['/courses', 'details', courseId]);
      },
      error: () =>
        this.toastr.error('Unable to update the lesson. Please try again.'),
    });
  }
}
