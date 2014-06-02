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
/{subjectKey}/Question/List
/{subjectKey}/Question/Create
/{subjectKey}/Question/Delete/{QuestionId}
/{subjectKey}/Question/Edit/{QuestionId}

Examination Paper:
/{subjectKey}/Paper/List
/{subjectKey}/Paper/Create
/{subjectKey}/Paper/Delete/{ExaminationPaperId}

Examination:
/{subjectKey}/ExamManage/List
/{subjectKey}/ExamManage/Archive/{ExaminationPaperId}
/{subjectKey}/ExamManage/Active/{ExaminationPaperId}

Evaluating:
/{subjectKey}/Eval/{ExaminationPaperId}/List
/{subjectKey}/Eval/{ExaminationPaperId}/Evalute

Student
-----
Testing:
/{subjectKey}/Test/{QuestionCategory}/[index -> datetime.now()]

Examination:
/{subjectKey}/Exam/My
/{subjectKey}/Exam/{ExaminationId}/Score

Answering:
/{subjectKey}/Exam/{ExaminationId}/Answering
