%get fit test900011000
V_main_len=test6in900011000(:,1);
BF9911=test6in900011000(:,2);
KMP9911=test6in900011000(:,3);
figure;
plot(V_main_len,test6in900011000(:,2),'LineWidth',1);
hold on
xlabel('Length of Main String /char');
ylabel('Duration /ms');
plot(V_main_len,test6in900011000(:,3),'LineWidth',1);
legend('BF','KMP','Location','NorthWest');
title('length of search string=6,n=5')
hold off