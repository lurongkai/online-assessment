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
/{SubjectId}/Question/List
/{SubjectId}/Question/New
/{SubjectId}/Question/Delete/{QuestionId}
/{SubjectId}/Question/Edit/{QuestionId}

Examination Paper:
/{SubjectId}/Paper/List
/{SubjectId}/Paper/New
/{SubjectId}/Paper/Delete/{ExaminationPaperId}

Examination:
/{SubjectId}/ExamManage/List
/{SubjectId}/ExamManage/Archive/{ExaminationPaperId}
/{SubjectId}/ExamManage/Active/{ExaminationPaperId}

Evaluating:
/{SubjectId}/Eval/{ExaminationPaperId}/List
/{SubjectId}/Eval/{ExaminationPaperId}/Evalute

Student
-----
Testing:
/{SubjectId}/Test/{QuestionCategory}/[index -> datetime.now()]

Examination:
/{SubjectId}/Exam/My
/{SubjectId}/Exam/{ExaminationId}/Score

Answering:
/{SubjectId}/Exam/{ExaminationId}/Answering
