Website URL
=====

Common
-----
Account:
/Account/Login
/Account/Register
/Account/LogOff

Unauthenticated Home:
/Home/Index

Authenticated Home:
/Home/Dashboard

Teacher
-----
Question:
/{courseId}/Question/List
/{courseId}/Question/Create
/{courseId}/Question/Delete/{QuestionId}
/{courseId}/Question/Edit/{QuestionId}

Examination Paper:
/{courseId}/Paper/List
/{courseId}/Paper/Create
/{courseId}/Paper/Delete/{ExaminationPaperId}

Examination:
/{courseId}/ExamManage/List
/{courseId}/ExamManage/Archive/{ExaminationPaperId}
/{courseId}/ExamManage/Active/{ExaminationPaperId}

Evaluating:
/{courseId}/Eval/{ExaminationPaperId}/List
/{courseId}/Eval/{ExaminationPaperId}/Evalute

Student
-----
Testing:
/{courseId}/Test/{QuestionCategory}/[index -> datetime.now()]

Examination:
/{courseId}/Exam/My
/{courseId}/Exam/{ExaminationId}/Score

Answering:
/{courseId}/Exam/{ExaminationId}/Answering
