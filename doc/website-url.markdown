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
/{courseName}/Question/List
/{courseName}/Question/Create
/{courseName}/Question/Delete/{QuestionId}
/{courseName}/Question/Edit/{QuestionId}

Examination Paper:
/{courseName}/Paper/List
/{courseName}/Paper/Create
/{courseName}/Paper/Delete/{ExaminationPaperId}

Examination:
/{courseName}/ExamManage/List
/{courseName}/ExamManage/Archive/{ExaminationPaperId}
/{courseName}/ExamManage/Active/{ExaminationPaperId}

Evaluating:
/{courseName}/Eval/{ExaminationPaperId}/List
/{courseName}/Eval/{ExaminationPaperId}/Evalute

Student
-----
Testing:
/{courseName}/Test/{QuestionCategory}/[index -> datetime.now()]

Examination:
/{courseName}/Exam/My
/{courseName}/Exam/{ExaminationId}/Score

Answering:
/{courseName}/Exam/{ExaminationId}/Answering
