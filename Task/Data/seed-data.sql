-- Insert main departments
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [ParentId], [logo], [IsDeleted]) VALUES 
(N'71eccfa8-f666-4b71-b56e-44030d20b725', N'Main Department 1', NULL, NULL, 0),
(N'41f035f4-bff5-4e07-a4ce-9ad09a0773c4', N'Main Department 2', NULL, NULL, 0),
(N'26e1fca2-f96b-42d5-97bc-8eee9a88ad6a', N'Main Department 3', NULL, NULL, 0),
(N'edfbf47d-8fe2-494e-b607-fcaa12f91248', N'Main Department 1', NULL, NULL, 0);

-- Insert sub-departments
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [ParentId], [logo], [IsDeleted]) VALUES 
(N'828c63b6-00df-4579-a4ea-9e2e469aafde', N'Subdepartment 1 for Main Department 1', N'71eccfa8-f666-4b71-b56e-44030d20b725', NULL, 0),
(N'53b3de09-ac06-404e-aa7b-930943533397', N'Subdepartment 2 for Main Department 1', N'71eccfa8-f666-4b71-b56e-44030d20b725', NULL, 0),
(N'85f8158f-8faa-4ceb-91ab-1571af78dd46', N'Subdepartment 1 for Main Department 2', N'41f035f4-bff5-4e07-a4ce-9ad09a0773c4', NULL, 0),
(N'695956a7-1065-41bd-9dde-874bef7b2a22', N'Subdepartment 2 for Main Department 2', N'41f035f4-bff5-4e07-a4ce-9ad09a0773c4', NULL, 0),
(N'849b96b4-0c68-494c-aae2-31a778831e52', N'Subdepartment 1 for Main Department 3', N'26e1fca2-f96b-42d5-97bc-8eee9a88ad6a', NULL, 0),
(N'25f58185-084d-46e8-b3f3-8534ec740836', N'Subdepartment 2 for Main Department 3', N'26e1fca2-f96b-42d5-97bc-8eee9a88ad6a', NULL, 0);

-- Insert sub-sub-departments
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [ParentId], [logo], [IsDeleted]) VALUES 
(N'd7ed5d5b-a048-4d57-9eff-a8282e142457', N'Sub-Subdepartment 1 for Subdepartment 1', N'828c63b6-00df-4579-a4ea-9e2e469aafde', NULL, 0),
(N'3f063e81-3d92-4535-a49a-02007a3786e7', N'Sub-Subdepartment 1 for Subdepartment 1', N'849b96b4-0c68-494c-aae2-31a778831e52', NULL, 0),
(N'8cbe8c2f-b4ff-46ca-8ee1-431662580904', N'Sub-Subdepartment 2 for Subdepartment 1', N'849b96b4-0c68-494c-aae2-31a778831e52', NULL, 0),
(N'be03431d-2a57-4e79-99d8-b80ee4add1e5', N'Sub-Subdepartment 1 for Subdepartment 1', N'849b96b4-0c68-494c-aae2-31a778831e52', NULL, 0),
(N'76728772-c0ee-4b1a-a6b6-a3d299edca59', N'Sub-Subdepartment 2 for Subdepartment 1', N'849b96b4-0c68-494c-aae2-31a778831e52', NULL, 0),
(N'f5ce2695-6c81-41f5-a383-4da6872718af', N'Sub-Subdepartment 2 for Subdepartment 1', N'849b96b4-0c68-494c-aae2-31a778831e52', NULL, 0),
(N'0461daa1-e5a8-4f55-8299-f82cad739caa', N'Sub-Subdepartment 1 for Subdepartment 1', N'85f8158f-8faa-4ceb-91ab-1571af78dd46', NULL, 0),
(N'4f1fe813-09c7-4d9a-8543-da353a84f712', N'Sub-Subdepartment 2 for Subdepartment 1', N'85f8158f-8faa-4ceb-91ab-1571af78dd46', NULL, 0);

-- Insert other sub-departments with missing parents as separate groups
-- Ensure the parent department for each of these exists
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [ParentId], [logo], [IsDeleted]) VALUES 
(N'b60011e0-ee06-4906-9c57-02af33774c30', N'Test2', N'3f063e81-3d92-4535-a49a-02007a3786e7', NULL, 0),
(N'2873a322-33e9-43ae-ad36-2a1d5e3667eb', N'Test3', N'edfbf47d-8fe2-494e-b607-fcaa12f91248', NULL, 0),
(N'0577295e-472c-4955-bd76-2d8057ea809d', N'Test', N'3f063e81-3d92-4535-a49a-02007a3786e7', N'/Upload/logos/Screenshot 2024-06-19 002532_1721479535381.png', 0),
(N'801b1fed-d5dd-4eaa-aa79-40d838511fb0', N'asd2', N'3f063e81-3d92-4535-a49a-02007a3786e7', N'2024_07_20.18_51_43_8957.png', 0),
(N'6b2ebb5d-88f0-4379-a10f-71b5dd2b4c8a', N'asd', N'3f063e81-3d92-4535-a49a-02007a3786e7', N'2024_07_20.18_49_21_2468.png', 0),
(N'813e9884-7327-4f41-938d-a0a60d672df0', N'Main Department 2', NULL, NULL, 0),
(N'd586f421-ba23-4322-8eb1-f0d748c4d06a', N'Main Department 3', NULL, NULL, 0);
