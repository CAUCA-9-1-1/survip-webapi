INSERT INTO public.webuser (id, username, password, is_active, created_on) VALUES
  ('d25a7a30-22e0-4169-95b8-bd36368f12d6', 'admin', '9c23261df316e6c33df0a87d3fc17bc5f4ec46cb1f303dfc5fd72074d6b68e48', true, '2017-05-29 09:03:30.134235');

INSERT INTO public.webuser_attributes (id, id_webuser, attribute_name, attribute_value) VALUES
  ('cf121d1d-723a-4b76-b262-bf159c1e5b2f', 'd25a7a30-22e0-4169-95b8-bd36368f12d6', 'last_name', 'Cauca'),
  ('932c2a2a-3a49-481d-85a4-59fdab3ed497', 'd25a7a30-22e0-4169-95b8-bd36368f12d6', 'reset_password', 'false'),
  ('deef114d-3a02-4701-a9c8-1379562c6096', 'd25a7a30-22e0-4169-95b8-bd36368f12d6', 'first_name', 'Admin');

-- Add all basic permission
INSERT INTO public.permission_system (id, description) VALUES
  ('2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'SURVI-Prevention');

INSERT INTO public.permission_system_feature (id, id_permission_system, feature_name, description, default_value) VALUES
  ('cf121d1d-723a-4b76-b262-bf159c1e5b2f', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'RightSectionSurvey', 'Voir la section questionnaire du site', false),
  ('932c2a2a-3a49-481d-85a4-59fdab3ed497', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'RightSectionManagement', 'Voir la section gestion du site', false),
  ('deef114d-3a02-4701-a9c8-1379562c6096', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'RightSectionInspection', 'Voir la section inspection du site', false),
  ('42f33044-026d-4023-a9ed-0c2dc20bda4e', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'RightAdmin', 'Accès en administration', false),
  ('f37a1f8a-2478-4b91-8d83-6db468b90c1d', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'RightTPI', 'Accès pour un TPI', false);

INSERT INTO public.permission_object (id, id_permission_object_parent, object_table, generic_id, id_permission_system, is_group, group_name) VALUES
  ('be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', null, 'group', '', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', true, 'Administration'),
  ('adca9ec0-4a96-474b-b97c-1e94c4fde32a', null, 'group', '', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', true, 'TPI'),
  ('d5d7d8ab-0416-48fe-997f-c7702118df8a', null, 'group', '', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', true, 'Pompier'),
  ('ef5aeb84-25ca-4bee-b359-ac5719a2567e', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', 'webuser', 'd25a7a30-22e0-4169-95b8-bd36368f12d6', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', false, null);

INSERT INTO public.permission (id, id_permission_object, id_permission_system, id_permission_system_feature, created_on, comments, access) VALUES
  ('75b81c00-1536-400d-b530-6ee084b6cc24', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'deef114d-3a02-4701-a9c8-1379562c6096', '2017-03-15 13:12:36.000000', null, true),
  ('8246f817-c6e6-4812-855b-44dfff92c700', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'cf121d1d-723a-4b76-b262-bf159c1e5b2f', '2017-03-15 13:12:32.000000', null, true),
  ('ae6060cb-de05-4c5e-ab1c-623b4c6ec640', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', '42f33044-026d-4023-a9ed-0c2dc20bda4e', '2017-03-15 13:06:36.000000', null, true),
  ('96fea7bb-eb9d-44b5-9bbd-4674ea5d1778', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', '932c2a2a-3a49-481d-85a4-59fdab3ed497', '2017-03-15 13:06:09.000000', null, true),
  ('2bd43a5d-7dcf-449f-ad17-5d6719246512', 'be1a8fae-1ceb-443d-9aa7-ea6c7c1b57d1', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'f37a1f8a-2478-4b91-8d83-6db468b90c1d', '2017-03-17 09:14:47.000000', null, true),
  ('3817af3d-7ce3-46a7-a630-affaad776ab7', 'adca9ec0-4a96-474b-b97c-1e94c4fde32a', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'deef114d-3a02-4701-a9c8-1379562c6096', '2017-03-15 11:39:18.000000', null, true),
  ('5947ad13-12c8-47a9-82d5-c06b8e1f33bc', 'adca9ec0-4a96-474b-b97c-1e94c4fde32a', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'cf121d1d-723a-4b76-b262-bf159c1e5b2f', '2017-03-15 11:38:37.000000', null, true),
  ('814a9371-e3e9-4485-abe9-27e48daf7eb4', 'd5d7d8ab-0416-48fe-997f-c7702118df8a', '2d9f85c6-c41b-4b53-b391-9caa31bb3494', 'deef114d-3a02-4701-a9c8-1379562c6096', '2017-03-15 15:33:56.000000', null, true);